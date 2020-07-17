/*
* To change this license header, choose License Headers in Project Properties.
* To change this template file, choose Tools | Templates
* and open the template in the editor.
*/
package javaapplication1;
import java.io.*;
import java.util.*;
import java.util.regex.*;
import java.sql.*;
import java.io.*;
import java.util.*;
import java.security.NoSuchAlgorithmException;
import java.security.spec.InvalidKeySpecException;
/**
*
* @author Kelvin
*/
public class contactTracing {
   public static final int TIME_PERIOD = 5;   // in days
   public static final int POPULATION = 5;
   public static final int MONTH = 1;
   public static final String GEN_FNAME = "Brandon";
   public static final String GEN_LNAME = "Ta";
   
   
   /**
   * @param args the command line arguments
   */
   public static void main(String[] args) {
      Scanner console = new Scanner(System.in);
      try {
         Query q = new Query();
         q.openConnection();
         q.prepareStatements();
         q.clearTable();
         
         int userType = userType(console);
         if (userType == 1) {
            manualUsers(q, console);
         } else if (userType == 2) {
            genUsers(q, console);
         }
         int userId = promptUserId(console);
         simulateDay(q, console, userId);
         q.closeConnection();
      } catch (IOException error) {
         println(error.getMessage());
      } catch (SQLException error) {
         println(error.getMessage());
      } catch (Exception error) {
         println(error.getMessage());
      }
   }
   
   public static int promptUserId(Scanner console) {
      println("What is your id?");
      int userId = console.nextInt();
      console.nextLine();
      println("");
      while (0 <= userId && userId <= POPULATION) {
         userId = console.nextInt();
         console.nextLine();
         println("");
      }
      return userId;
   }
   
   public static int userType(Scanner console) {
      println("Would you like to manually enter in users (1) or randomly " +
                 "generate users (2)");    
      int userType = console.nextInt();
      console.nextLine();
      println("");
      while (userType != 1 && userType != 2) {
         println("Would you like to manually enter in users (1) or randomly " +
              "generate users (2)");
         userType = console.nextInt();
         console.nextLine();
      }
      return userType;
   }
   
   public static void manualUsers(Query q, Scanner console) throws NoSuchAlgorithmException, InvalidKeySpecException, Exception {
      for (int i = 0; i < POPULATION; i++) {
         println("Person " + (i + 1));
         print("Enter First Name: ");
         String fname = console.nextLine();
         print("Enter Last Name: ");
         String lname = console.nextLine();
         print("Enter Phone Number: ");
         String phone = console.nextLine();
         print("Enter Address: ");
         String address = console.nextLine();
         q.insertUser(fname, lname, phone, address, "password");
         println("");
      }
   }
   
   public static void genUsers(Query q, Scanner console) throws NoSuchAlgorithmException, InvalidKeySpecException, Exception {
      for (int i = 0; i < POPULATION; i++) {
         println("Person " + (i + 1));
         String fname = GEN_FNAME + (i + 1);
         String lname = GEN_LNAME + (i + 1);
         String phone = genPhone();
         String address = "Seattle, WA";
         q.insertUser(fname, lname, phone, address, "password");
         println(fname);
         println(lname);
         println(phone);
         println(address);
         println("");
      }
   }
   
   public static void simulateDay(Query q, Scanner console, int userId) throws SQLException {
      for (int i = 0; i < TIME_PERIOD; i++) {
         int day = i + 1;
         println("Today is " + MONTH + "/" + day);
         int rdmPerson = randomPerson(userId);
         println("You ran into Person " + rdmPerson);
         q.insertInteraction(MONTH, day, userId, rdmPerson);
         println("Would you like to self-report? (y/n)");
         String resp = console.nextLine();
         while (!resp.equals("y") && !resp.equals("n")) {
            println("Would you like to self-report? (y/n)");
            resp = console.nextLine();
         }
         if (resp.equals("y")) {
            int[] atRisk = q.findUser(userId);
            for (int id: atRisk) {
               println("Person " + id + " is at risk");
            }
            q.closeConnection();
            break;
         } else if (resp.equals("n")) {
            println("");
         }
      }
   }
   
   public static int randomPerson(int userId) {
      int rdm = (int)(Math.random() * POPULATION);
      while (rdm == userId) {
         rdm = (int)(Math.random() * POPULATION);
      }
      return rdm;
   }
   
   public static String genPhone() {
      String phone = "(253)-";
      for (int i = 0; i < 3; i++) {
         phone += (int)(Math.random() * 9);
      }
      phone += "-";
      for (int i = 0; i < 4; i++) {
         phone += (int)(Math.random() * 9);
      }
      return phone;
   }
   
   public static void print(String text) {
      System.out.print(text);
   }
   
   public static void println(String text) {
      System.out.println(text);
   }
   
}
