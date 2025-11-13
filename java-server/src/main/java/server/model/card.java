package main.java.server.model;

import java.awt.*;
import java.awt.image.BufferedImage;

public class Card {
    int cardId;
    int userId;
    boolean isPublic;
    Image baseImage;
    BufferedImage cardImage;
    String cardName;
    int life;
    int damage;
    int shield;
    String type;

    public int getCardId() {
        return cardId;
    }

    public void setCardId(int cardId) {
        this.cardId = cardId;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public boolean getIsPublic() {
        return isPublic;
    }

    public void setIsPublic(boolean ppublic) {
        this.isPublic = ppublic;
    }

    public Image getBaseImage() {
        return baseImage;
    }

    public void setBaseImage(Image baseImage) {
        this.baseImage = baseImage;
    }

    public BufferedImage getCardImage() {
        return cardImage;
    }

    public void setCardImage(BufferedImage cardImage) {
        this.cardImage = cardImage;
    }

    public String getCardName() {
        return cardName;
    }

    public void setCardName(String cardName) {
        this.cardName = cardName;
    }

    public int getLife() {
        return life;
    }

    public void setLife(int life) {
        this.life = life;
    }

    public int getDamage() {
        return damage;
    }

    public void setDamage(int damage) {
        this.damage = damage;
    }

    public int getShield() {
        return shield;
    }

    public void setShield(int shield) {
        this.shield = shield;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }



    public Card(int cardId, String name, int userId, boolean isPublic, Image baseImage, BufferedImage image,
                int life, int damage, int shield, String type) {
        this.cardId = cardId;
        this.cardName = name;
        this.userId = userId;
        this.isPublic = isPublic;
        this.baseImage = baseImage;
        this.cardImage = image;
        this.life = life;
        this.damage = damage;
        this.shield = shield;
        this.type = type;

        if(cardImage == null) CreateCardImage(baseImage);
    }

    private void CreateCardImage(Image baseimg){
        int width = 200;
        int height = 300;
        int margin = 15;

        //create img
        BufferedImage cardImage = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        Graphics2D g = cardImage.createGraphics();

        g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        g.setRenderingHint(RenderingHints.KEY_TEXT_ANTIALIASING, RenderingHints.VALUE_TEXT_ANTIALIAS_ON);

        g.setColor(new Color(240, 240, 240));
        g.fillRoundRect(0, 0, width, height, 20, 20);

        //name
        g.setFont(new Font("Arial", Font.BOLD, 18));
        g.setColor(Color.BLACK);
        g.drawString(this.cardName, margin, 30);

        //image
        g.drawImage(baseimg, margin, 40, width-(margin * 2),180, null);

        //attributes
        g.setFont(new Font("Arial", Font.BOLD, 14));
        int statY = 240;
        g.drawString("LIFE: " + this.life, 10, statY);
        g.drawString("DAMAGE: " + this.damage, 10, statY + 25);
        g.drawString("SHIELD: " + this.shield, 10, statY + 50);

        g.dispose();
        this.cardImage = cardImage;

    }

}
