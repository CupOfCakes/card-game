package main.java.server;

import main.java.server.handlers.CardHandler;
import main.java.server.handlers.DeckHandler;
import main.java.server.handlers.LoginHandler;
import main.java.server.handlers.MainScreenHandler;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class playerHandler implements Runnable {
    private final Socket clientSocket;


    public playerHandler(Socket socket) {
        this.clientSocket = socket;
    }

    @Override
    public void run() {

        try (BufferedReader in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
             PrintWriter out = new PrintWriter(clientSocket.getOutputStream(), true)
        ) {

            String input;

            while ((input = in.readLine()) != null) {
                if(input.startsWith("LOGIN:")){
                    LoginHandler.login(input, out);
                } else if(input.startsWith("NEWLOGIN:")){
                    LoginHandler.newLogin(input, out);
                }else if(input.startsWith("CHANGELOGIN:")) {
                    LoginHandler.changeLogin(input, out);
                }else if(input.startsWith("CLIENTNAME:")){
                    MainScreenHandler.LB_Name(input, out);
                }else if(input.startsWith("DECK:")){
                    DeckHandler.GetDeck(input, out);
                }else if(input.startsWith("NEWCARD:")){
                    CardHandler.createCard(input, out);
                }
                else {
                    out.println("I am 4 Parallel Universes ahead of you");
                }

            }
        } catch (IOException e) {
            System.out.println("Connection lost");;
        }
    }
}
