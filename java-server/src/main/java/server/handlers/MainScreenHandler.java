package main.java.server.handlers;

import main.java.server.util.DBConnection;

import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class MainScreenHandler {

    public static void LB_Name(String input, PrintWriter out){
        String userIdHolder = input.split(":")[1];
        int userId = Integer.parseInt(userIdHolder);

        try(Connection conn = DBConnection.getConnection();
            PreparedStatement stmt = conn.prepareStatement(
                    "SELECT name FROM users WHERE id = ?")){
            stmt.setInt(1, userId);

            try (ResultSet rs = stmt.executeQuery()){
                if(rs.next()){
                    out.println(rs.getString("name"));
                }else{
                    out.println("User not found");
                }
            }
        } catch (SQLException e) {
            out.println(e.getMessage());
            e.printStackTrace();
        }

    }
}
