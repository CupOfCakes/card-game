package main.java.server.handlers;

import main.java.server.util.DBConnection;

import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class ConfigHandler {

    public static void DeleteAcoount(String input, PrintWriter out){
        String userIdHolder = input.split(":")[1];
        int userId = Integer.parseInt(userIdHolder);

        try(Connection conn = DBConnection.getConnection();
            PreparedStatement stmt = conn.prepareStatement(
                    "DELETE FROM users WHERE id = ?");){
            stmt.setInt(1, userId);

            conn.setAutoCommit(false);


            int rowsAffected = stmt.executeUpdate();

            if(rowsAffected == 1){
                out.println("Deleted Successfully");
                conn.commit();
            }
            else if(rowsAffected > 1){
                out.println("Deleted Failed (multiple rows affected)");
            } else {
                out.println("No one was deleted");
            }

        } catch (SQLException e) {
            out.println(e.getMessage());
            e.printStackTrace();
        }

    }
}
