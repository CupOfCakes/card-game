package main.java.server.handlers;

import main.java.server.util.DBConnection;

import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import static main.java.server.util.HashingUtils.hash;

public class LoginHandler {

    public static void login(String input, PrintWriter out){
        String[] parts = input.substring(6).split(";");

        if (parts.length != 2) {
            out.println("INVALID_FORMAT");
            return;
        }

        String user = parts[0];
        String hashedPassword = hash(parts[1]);

        try(Connection conn = DBConnection.getConnection();
        PreparedStatement stmt = conn.prepareStatement(
                "SELECT id FROM users WHERE name = ? AND password = ?")) {
            stmt.setString(1, user);
            stmt.setString(2, hashedPassword);

            try(ResultSet rs = stmt.executeQuery()) {
                if(rs.next()){
                    int userId = rs.getInt("id");
                    out.println("LOGIN_OK;" + userId);
                } else {
                    out.println("user or password incorrect");
                }
            }

        } catch(SQLException e){
            out.println(e.getMessage());
            e.printStackTrace();
        }

    } //make login


    public static void newLogin(String input, PrintWriter out){
        String[] parts = input.substring(9).split(";");

        if (parts.length != 2) {
            out.println("INVALID_FORMAT");
            return;
        }

        String user = parts[0];
        String hashedPassword = hash(parts[1]);

        try(Connection conn = DBConnection.getConnection();
            PreparedStatement stmt = conn.prepareStatement(
                    "INSERT INTO users (name, password) VALUES (?, ?)")) {
            stmt.setString(1, user);
            stmt.setString(2, hashedPassword);

            int rowsAffected = stmt.executeUpdate();

            if(rowsAffected == 1){
                out.println("user successfully created");
            }
            else {
                out.println("Error creating user");
            }

        } catch(SQLException e){
            if(e.getSQLState().equals("23505")){
                out.println("USER_EXISTS");
            }else {
                out.println("ERRO: user not created");
                e.printStackTrace();
            }
        }
    }


    public static void changeLogin(String input, PrintWriter out){
        String[] parts = input.substring(12).split(";");

        if(parts.length != 2){
            out.println("INVALID_FORMAT");
            return;
        }

        String user = parts[0];
        String hashedPassword = hash(parts[1]);

        try(Connection conn = DBConnection.getConnection();
            PreparedStatement stmt = conn.prepareStatement(
                    "UPDATE users SET password = ? WHERE name = ?")) {
            stmt.setString(1, hashedPassword);
            stmt.setString(2, user);

            int rowsAffected = stmt.executeUpdate();

            if(rowsAffected == 1){
                out.println("Password successfully updated");
            }
            else {
                out.println("Error updating password");
            }

        } catch(SQLException e){
            out.println("ERRO: password not updated");
            e.printStackTrace();
        }
    }

}
