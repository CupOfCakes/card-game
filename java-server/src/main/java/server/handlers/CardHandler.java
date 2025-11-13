package main.java.server.handlers;

import main.java.server.model.Card;
import main.java.server.util.DBConnection;
import main.java.server.util.ImageUtils;
import org.json.JSONObject;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.Base64;

public class CardHandler {
    public static void createCard(String input, PrintWriter out) throws IOException {
        String json = input.substring(input.indexOf(":")+1);
        JSONObject obj = new JSONObject(json);

        String name = obj.optString("CardName");
        int userId = obj.optInt("UserId");
        boolean isPublic = obj.optBoolean("public", true);
        int life = obj.optInt("Life", 0);
        int damage = obj.optInt("Damage", 0);
        int shield = obj.optInt("Shield", 0);
        String type = obj.optString("Type", "");
        String imageBase64 = obj.optString("ImageBase64", null);

        BufferedImage baseImage = null;

        if(imageBase64 != null){
            byte[] imageBytes = Base64.getDecoder().decode(imageBase64);
            baseImage = ImageIO.read(new ByteArrayInputStream(imageBytes));
        }

        Card card = new Card(
                0,
                name,
                userId,
                isPublic,
                baseImage,
                null,
                life,
                damage,
                shield,
                type
        );

        BufferedImage baseBuf = ImageUtils.imageToBufferedImage(card.getBaseImage());

        try(Connection conn = DBConnection.getConnection();
            PreparedStatement stmt = conn.prepareStatement(
                    "INSERT INTO cards (name, id_creator, public, image, card, life, damage, shield, type) " +
                            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"
            )) {
                stmt.setString(1, card.getCardName());
                stmt.setInt(2, card.getUserId());
                stmt.setBoolean(3, card.getIsPublic());
                stmt.setBytes(4, ImageUtils.imageToBytes(baseBuf));
                stmt.setBytes(5, ImageUtils.imageToBytes(card.getCardImage()));
                stmt.setInt(6, card.getLife());
                stmt.setInt(7, card.getDamage());
                stmt.setInt(8, card.getShield());
                stmt.setString(9, card.getType());

                int rowsAffected = stmt.executeUpdate();

                if(rowsAffected == 0){
                    out.println(name + " was not created");
                } else if(rowsAffected == 1){
                    out.println(name + " was created");
                }
                else{
                    out.println("WTF IS HAPPENING");
                }
        } catch (SQLException e) {
           e.printStackTrace();
           out.println("ERRO: "+ e.getMessage());
        }

    }
}
