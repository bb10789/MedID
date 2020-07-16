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
/**
*
* @author Kelvin
*/
public class contactTracing {
   public static final int TIME_PERIOD = 1;
   public static final int POPULATION = 2;
   public static final int MONTH = 1;
   
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
            q.insertUser(fname, lname, phone, address);
            println("");
         }
         
         // for (int i = 0; i < TIME_PERIOD; i++) {
//             int day = i + 1;
//             println("What is your id?");
//             int id = console.nextInt();
//             println("Today is " + MONTH + "/" + day);
//             int rdmPerson = 
//             println("You ran into 
//          }
      } catch (IOException error) {
         System.out.println(error.getMessage());
      } catch (SQLException error) {
         System.out.println(error.getMessage());
      }
   }
   
   public static void print(String text) {
      System.out.print(text);
   }
   
   public static void println(String text) {
      System.out.println(text);
   }
   
}
