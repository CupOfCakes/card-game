package main.java.server;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

import java.sql.*;

import static main.java.security.messageDigest.Criptography.hash;

public class playerHandler implements Runnable{
    private final Socket clientSocket;



    private static final String URL = "jdbc:postgresql://localhost:5432/card_game";
    private static final String USER = "postgres";
    private static final String PASSWORD = "postgres";

    public playerHandler(Socket socket){
        this.clientSocket = socket;
    }

    @Override
    public void run() {

        try(BufferedReader in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
            PrintWriter out = new PrintWriter(clientSocket.getOutputStream(),true)
        ) {
            Class.forName("org.postgresql.Driver");

            String input;

            while((input = in.readLine()) != null){
                if(input.startsWith("LOGIN:")){
                    String[] parts = input.substring(6).split(";");

                    if(parts.length != 2){
                        out.println("INVALID_FORMAT");
                        continue;
                    }

                    String user = parts[0];
                    String hashedPassword = hash(parts[1]);

                    try(Connection conn = DriverManager.getConnection(URL, USER, PASSWORD);
                        PreparedStatement stmt = conn.prepareStatement(
                                "SELECT 1 FROM users WHERE name = ? AND password = ?")){
                        stmt.setString(1, user);
                        stmt.setString(2, hashedPassword);

                        try(ResultSet rs = stmt.executeQuery()){
                            if(rs.next()){
                                int userId = rs.getInt("id");
                                out.println("LOGIN_OK;" + userId);
                            }
                            else{
                                out.println("LOGIN_FAIL");
                            }
                        }

                    }catch(SQLException e){
                        out.println("DB_ERROR");
                        e.printStackTrace();
                    }

                }
                else if(input.startsWith("NEWLOGIN:")){
                    String[] parts = input.substring(9).split(";");

                    if(parts.length != 2){
                        out.println("INVALID_FORMAT");
                        continue;
                    }

                    String user = parts[0];
                    String hashedPassword = hash(parts[1]);

                    try(Connection conn = DriverManager.getConnection(URL, USER, PASSWORD);
                        PreparedStatement stmt = conn.prepareStatement(
                                "INSERT INTO users (name, password) VALUES (?, ?)")){
                        stmt.setString(1, user);
                        stmt.setString(2, hashedPassword);

                        int rowsAffected = stmt.executeUpdate();

                        if(rowsAffected == 1){
                            out.println("user successfully created");
                        }
                        else {
                            out.println("Error creating user");
                        }


                    }catch(SQLException e){
                        if(e.getSQLState().equals("23505")){
                            out.println("USER_EXISTS");
                        }else {
                            out.println("DB_ERROR");
                            e.printStackTrace();
                        }
                    }

                }
                else if(input.startsWith("CHANGELOGIN:")){
                    String[] parts = input.substring(12).split(";");

                    if(parts.length != 2){
                        out.println("INVALID_FORMAT");
                        continue;
                    }

                    String user = parts[0];
                    String hashedPassword = hash(parts[1]);

                    try(Connection conn = DriverManager.getConnection(URL, USER, PASSWORD);
                        PreparedStatement stmt = conn.prepareStatement(
                                "UPDATE users SET password = ? WHERE name = ? AND password = <>")){
                        stmt.setString(1, hashedPassword);
                        stmt.setString(2, user);
                        stmt.setString(3, hashedPassword);

                        int rowsAffected = stmt.executeUpdate();

                        if(rowsAffected == 1){
                            out.println("Password successfully updated");
                        } else {
                            out.println("Error updating password");
                        }


                    }catch(SQLException e){
                        out.println("DB_ERROR");
                        e.printStackTrace();
                    }
                }




                else if(input.equals("I LOVE YOU S2")){
                    out.println("I LOVE YOU TOO ^///^");
                }
                else {
                    out.println("I am 4 Parallel Universes ahead of you");
                }



            }


        } catch (IOException e) {
            System.out.println("Cliente desconhecido");
        } catch (ClassNotFoundException e) {
            System.out.println("Cliente desconhecido2");
        }
    }
}
