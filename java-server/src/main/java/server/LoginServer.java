package main.java.server;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;


public class LoginServer {


    public static void main(String[] args) {
        try(ServerSocket server = new ServerSocket(5000)){

            while(true){
                Socket clientSocket = server.accept();
                //System.out.println("novo cliente conectado");
                new Thread(new playerHandler(clientSocket)).start();
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
