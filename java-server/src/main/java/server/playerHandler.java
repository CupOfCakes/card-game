package main.java.server;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

import java.sql.*;

public class playerHandler implements Runnable{
    private Socket clientSocket;

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
            String input;

            while((input = in.readLine()) != null){
                if(input.startsWith("LOGIN:")){
                    String[] parts = input.substring(6).split(";");
                    String user = parts[0];
                    String password = parts[1];

                    try(Connection conn = DriverManager.getConnection(URL, USER, PASSWORD);
                        PreparedStatement stmt = conn.prepareStatement(
                                "SELECT * FROM players WHERE username = ? AND password = ?")){
                        stmt.setString(1, user);
                        stmt.setString(2, password);

                        try(ResultSet rs = stmt.executeQuery()){
                            if(rs.next()){
                                out.println("LOGIN_OK");
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
                else if(input.equals("I LOVE YOU S2")){
                    out.println("I LOVE YOU TOO ^///^");
                }



            }


        } catch (IOException e) {
            System.out.println("Cliente desconhecido");
        }
    }
}
