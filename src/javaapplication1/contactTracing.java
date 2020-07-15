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
/**
 *
 * @author Kelvin
 */
public class contactTracing {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException, SQLException {
       Query x = new Query();
       x.openConnection();
       x.prepareStatements();
       int[] y = x.findUser(0);
       System.out.println(y[0] + "," + y[1]);
    }
    
}
