package main.java.server.teste;

import main.java.server.model.Card;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;

public class TestCardImage {

    public static void main(String[] args) {
        try {
            // cria uma imagem base só pra testar
            BufferedImage fakeImg = new BufferedImage(300, 200, BufferedImage.TYPE_INT_RGB);
            Graphics2D g = fakeImg.createGraphics();
            g.setColor(Color.ORANGE);
            g.fillRect(0, 0, 300, 200);
            g.setColor(Color.BLACK);
            g.drawString("IMAGEM BASE TESTE", 50, 100);
            g.dispose();

            // cria um card de exemplo
            Card c = new Card("Gamma Jack", 67, 42, 12);

            // gera a imagem usando o método
            c.CreateCardImage(fakeImg);

            // salva pra testar
            File output = new File("card_teste.png");
            ImageIO.write(c.getCardImage(), "png", output);

            System.out.println("Imagem salva como: " + output.getAbsolutePath());

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
