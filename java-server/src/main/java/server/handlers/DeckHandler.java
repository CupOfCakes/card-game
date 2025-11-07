package main.java.server.handlers;

import main.java.server.model.Card;
import main.java.server.util.DBConnection;
import static main.java.server.util.ImageUtils.*;

import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class DeckHandler {


    public static List<Card> GetDeck(String input, PrintWriter out) {
        String userIdHolder = input.split(":")[1];
        int userId = Integer.parseInt(userIdHolder);

        List<Card> deck = new ArrayList<>();

        try(Connection conn = DBConnection.getConnection();
            PreparedStatement stmt = conn.prepareStatement(
        """
            SELECT *
            FROM cards
            WHERE id = any(
                SELECT unnest(cards_id)
                FROM deck
                WHERE user_id = ?)
            """
            )) {
            stmt.setInt(1, userId);

            ResultSet rs = stmt.executeQuery();

            while (rs.next()){
                BufferedImage cardImage = readBImageFromBytes(rs.getBytes("image"));
                Image baseImage = readImageFromBytes(rs.getBytes("card"));


                Card card = new Card(
                        rs.getInt("id"),
                        rs.getString("name"),
                        rs.getInt("id_creator"),
                        rs.getBoolean("public"),
                        baseImage,
                        cardImage,
                        rs.getInt("life"),
                        rs.getInt("damage"),
                        rs.getInt("shield"),
                        rs.getString("type")
                );

                deck.add(card);
            }

        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
        return deck;

    }

}
