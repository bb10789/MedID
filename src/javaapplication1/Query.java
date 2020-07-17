/*
Basic java to SQL connection for inserting user, interaction, and recieve the 
list of user a specific user has interacted with

to be done:
Delete data every 15 days
connect to actual database
 */
package javaapplication1;

import java.io.*;
import java.sql.*;
import java.util.*;
import java.security.*;
import java.security.spec.*;
import javax.crypto.*;
import javax.crypto.spec.*;
import javax.sound.sampled.FloatControl;
import java.sql.DriverManager;
import java.time.temporal.Temporal;

/**
 *
 * @author Kelvin
 */
public class Query {

    private Connection conn;
    private int userID = 0;
    private int interactionID = 0;

    private static final String FIND_USER = "SELECT i.id2 AS otherID, COUNT(*) over() AS cnt\n"
            + "FROM Interaction as i\n"
            + "WHERE i.id1 == ?";
    private PreparedStatement findUserStatement;
    private static final String INSERT_USER = "INSERT INTO ID VALUES (?, ?, ?, ?, ?, ?, ?)";
    private PreparedStatement insertUserStatement;
    private static final String INSERT_INTERACTION = "INSERT INTO INTERACTION VALUES (?, ?, ?, ?, ?)";
    private PreparedStatement insertInteractionStatement;
    private static final String CLEAR_TABLE = "DELETE FROM ID;";
    private static final String CLEAR_TABLE_INTER = "DELETE FROM INTERACTION";
    private PreparedStatement clearTableInter;
    private PreparedStatement clearTableStatement;
    private static final String GET_SALT = "Select id.salt AS salt, id.password AS pass\n"
            + "FROM ID AS id\n"
            + "Where id.id = ?";
    private PreparedStatement getSaltStatement;

    public void openConnection() throws IOException, SQLException {
        conn = null;
        try {
            String url = "jdbc:sqlite:../MEDID.db"; //change filepath to ../MEDID.db and change back before push
            conn = DriverManager.getConnection(url);
            System.out.println("Connection to SQLite has been established");

        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void closeConnection() throws SQLException {
        conn.close();
    }

    // Prepare SQL Statements
    public void prepareStatements() throws SQLException {
        findUserStatement = conn.prepareStatement(FIND_USER);
        insertUserStatement = conn.prepareStatement(INSERT_USER);
        insertInteractionStatement = conn.prepareStatement(INSERT_INTERACTION);
        clearTableStatement = conn.prepareStatement(CLEAR_TABLE);
        getSaltStatement = conn.prepareStatement(GET_SALT);
        clearTableInter = conn.prepareStatement(CLEAR_TABLE_INTER);
    }

    // insert Users' personal information
    public void insertUser(String fname, String lname, String phone, String address,
            String password) throws NoSuchAlgorithmException, InvalidKeySpecException, Exception {
        try {
            insertUserStatement.clearParameters();
            insertUserStatement.setInt(1, userID++);
            insertUserStatement.setString(2, fname);
            insertUserStatement.setString(3, lname);
            insertUserStatement.setString(4, phone);
            insertUserStatement.setString(5, address);
            byte[] salt = PBKDF2WithHmacSHA512.salt();
            String ssalt = PBKDF2WithHmacSHA512.convertToString(salt);
            byte[] pass = PBKDF2WithHmacSHA512.hash(password, salt);
            insertUserStatement.setString(6, PBKDF2WithHmacSHA512.convertToString(pass));
            insertUserStatement.setString(7, ssalt);
            insertUserStatement.execute();
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }

    // Check if the password is correct
    // pre: ID must be within valid range 
    // post: return true if password is correct
    public boolean authenticate(int id, String password) throws Exception {
        if (id >= userID) {
            System.out.println("Invalid ID");
            return false;
        }
        try {
            getSaltStatement.clearParameters();
            getSaltStatement.setInt(1, id);
            ResultSet result = getSaltStatement.executeQuery();
            String ssalt, sPass;
            ssalt = result.getString("salt");
            sPass = result.getString("pass"); // actual password
            byte[] saltByte = PBKDF2WithHmacSHA512.toByteArray(ssalt);
            byte[] realPasswordByte = PBKDF2WithHmacSHA512.toByteArray(sPass);
            return PBKDF2WithHmacSHA512.authenticate(password, saltByte, realPasswordByte);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }

    // insert an interaction
    // check conditons for month, dayOfMonth, id1, id2
    public void insertInteraction(int month, int dayOfMonth, int id1, int id2) {
        if (id1 >= userID || id2 >= userID) {
            System.out.println("Invalid ID");
            return;
        }
        if (month < 0 || month > 12) {
            System.out.println("Invalid Month");
            return;
        }
        if (dayOfMonth < 0 || dayOfMonth > 31) {
            System.out.println("Invalid Date");
            return;
        }
        try {
            insertInteractionStatement.clearParameters();
            insertInteractionStatement.setInt(1, interactionID++);
            insertInteractionStatement.setInt(2, month);
            insertInteractionStatement.setInt(3, dayOfMonth);
            insertInteractionStatement.setInt(4, id1);
            insertInteractionStatement.setInt(5, id2);
            insertInteractionStatement.execute();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    // Returns the id of every user that has interacted with the given id
    // preconditon: id must be valid
    // postconditon: Returns an int array of all the users interated with
    public int[] findUser(int id) {
        if (id < 0) {
            System.out.println("Invalid User");
            return null;
        }
        int[] storage;
        int count = 0;
        try {
            findUserStatement.clearParameters();
            findUserStatement.setInt(1, id);
            ResultSet result = findUserStatement.executeQuery();
            int size = result.getInt("cnt");
            result.getInt("otherID");
            storage = new int[size];
            while (result.next()) {
                int Temp = result.getInt("otherID");
                storage[count++] = Temp;
            }

        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
        return storage;
    }

    public void clearTable() {
        try {
            clearTableStatement.execute();
            clearTableInter.execute();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

}
