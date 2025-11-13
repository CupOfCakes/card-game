package main.java.server.handlers;

import main.java.server.model.Card;
import main.java.server.util.DBConnection;
import static main.java.server.util.ImageUtils.*;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.util.Base64;
import org.json.JSONArray;
import org.json.JSONObject;

import javax.imageio.ImageIO;
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


    public static void GetDeck(String input, PrintWriter out) {
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
                BufferedImage cardImage = readBImageFromBytes(rs.getBytes("card"));
                Image baseImage = readImageFromBytes(rs.getBytes("image"));


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

        sendDeckToClient(deck, out);

    }

    public static void sendDeckToClient(List<Card> deck, PrintWriter out) {
        JSONArray deckArray = new JSONArray();

        for(Card card : deck){
            JSONObject cardJson = new JSONObject();

            cardJson.put("id", card.getCardId());
            cardJson.put("name", card.getCardName());
            cardJson.put("userId", card.getUserId());
            cardJson.put("public", card.getIsPublic());
            cardJson.put("life", card.getLife());
            cardJson.put("damage", card.getDamage());
            cardJson.put("shield", card.getShield());
            cardJson.put("type", card.getType());

            if (card.getBaseImage() != null)
                cardJson.put("image", encodeImageToBase64(card.getBaseImage()));

            if (card.getCardImage() != null)
                cardJson.put("card", encodeBufferedImageToBase64(card.getCardImage()));

            deckArray.put(cardJson);

        }

        JSONObject deckJson = new JSONObject();
        deckJson.put("deck", deckArray);

        out.println(deckJson.toString());

    }

    private static String encodeBufferedImageToBase64(BufferedImage img) {
        try(ByteArrayOutputStream out = new ByteArrayOutputStream()) {
            ImageIO.write(img, "png", out);
            return Base64.getEncoder().encodeToString(out.toByteArray());
        } catch (IOException e){
            e.printStackTrace();
            return null;
        }
    }

    private static String encodeImageToBase64(Image image) {
        if(!(image instanceof BufferedImage)){
            BufferedImage bimage = new BufferedImage(
                    image.getWidth(null), image.getHeight(null), BufferedImage.TYPE_INT_RGB);

            Graphics g = bimage.getGraphics();
            g.drawImage(image, 0, 0, null);
            g.dispose();
            return encodeBufferedImageToBase64(bimage);
        }
        return encodeBufferedImageToBase64((BufferedImage) image);
    }



}
