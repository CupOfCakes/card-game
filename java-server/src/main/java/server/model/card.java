package main.java.server.model;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

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

    //CORES
    private static final Color COR_BORDA = new Color(0x0C1D2A); // #02031A (Escuro Profundo)

    private static final Color COR_FUNDO_SECOES = new Color(0x78A9C0, true); // #EBFDCC (Bege Claro) - com transparência
    private static final Color COR_TEXTO_SECOES = Color.BLACK;
    private static final Color COR_TEXTO_STATS = new Color(0x02031A); // #02031A (Escuro Profundo) - para texto em fundo bege

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

    public Card(String name, int life, int damage, int shield) {
        this.cardName = name;
        this.life = life;
        this.damage = damage;
        this.shield = shield;
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

    public void CreateCardImage(Image baseCharacterImage) {
        int width = 300;
        int height = 450;
        int margin = 20;

        int panelWidth = width - (margin * 2);
        int artHeight = 250;
        int artY = margin;

        int statsHeight = height - (artY + artHeight) - margin;
        int statsY = artY + artHeight;

        // --- 1. Carregar a Imagem de Fundo do Card ---
        BufferedImage backgroundCardImage = null;
        try {
            backgroundCardImage = ImageIO.read(new File("src/main/resources/CardBackground.png"));
            // Redimensiona o fundo para o tamanho do card, se necessário
            backgroundCardImage = resizeImage(backgroundCardImage, width, height);
        } catch (IOException e) {
            System.err.println("ERRO: 'fundo_card.png' não encontrado. Garanta que o arquivo está na pasta.");
            // Em caso de erro, usa uma cor sólida para o fundo (para não travar)
            backgroundCardImage = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
            Graphics2D gTemp = backgroundCardImage.createGraphics();
            gTemp.setColor(new Color(0x02031A)); // Cor de backup
            gTemp.fillRect(0, 0, width, height);
            gTemp.dispose();
        }

        // 2. Inicializar o Gráfico
        BufferedImage cardImage = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        Graphics2D g = cardImage.createGraphics();

        g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        g.setRenderingHint(RenderingHints.KEY_TEXT_ANTIALIASING, RenderingHints.VALUE_TEXT_ANTIALIAS_ON);

        // --- 3. Desenho dos Elementos ---

        // 3.1. Desenhar a Imagem de Fundo do Card
        g.drawImage(backgroundCardImage, 0, 0, null);

        // 3.2. Borda do Card Principal (Azul Petróleo: #021B2B)
        g.setColor(COR_BORDA);
        g.setStroke(new java.awt.BasicStroke(5));
        g.drawRoundRect(0, 0, width-1, height-1, 25, 25);


        // 4.1. Área para Nome e Imagem (Fundo Bege Claro Semi-Transparente)
        g.setColor(new Color(COR_FUNDO_SECOES.getRed(), COR_FUNDO_SECOES.getGreen(), COR_FUNDO_SECOES.getBlue(), 200)); // Transparência para o fundo
        g.fillRoundRect(margin, artY, panelWidth, artHeight, 20, 20);

        // 4.1.1. Borda para a Área de Nome/Imagem (Azul Petróleo: #021B2B)
        g.setColor(COR_BORDA);
        g.setStroke(new java.awt.BasicStroke(3));
        g.drawRoundRect(margin, artY, panelWidth, artHeight, 20, 20);

        // 4.2. Imagem Central
        int imgX = margin + 10;
        int imgY = artY + 40;
        int imgW = panelWidth - 20;
        int imgH = artHeight - 50;

        Image scaled = baseCharacterImage.getScaledInstance(imgW, imgH, Image.SCALE_SMOOTH);
        g.drawImage(scaled, imgX, imgY, null);

        // 4.3. Nome
        g.setFont(new Font("Arial", Font.BOLD, 24));
        g.setColor(COR_TEXTO_SECOES); // Texto preto em fundo bege claro

        int nameWidth = g.getFontMetrics().stringWidth(this.cardName);
        int xName = margin + (panelWidth - nameWidth) / 2;
        g.drawString(this.cardName, xName, artY + 30);

        // 4.4. Área Inferior para Stats (Fundo Bege Claro Semi-Transparente)
        g.setColor(new Color(COR_FUNDO_SECOES.getRed(), COR_FUNDO_SECOES.getGreen(), COR_FUNDO_SECOES.getBlue(), 200)); // Fundo Bege Claro com transparência
        g.fillRoundRect(margin, statsY, panelWidth, statsHeight, 15, 15);

        // 4.4.1. Borda de Destaque para Stats (Vermelho Neon: #FF0841)
        g.setColor(COR_BORDA);
        g.setStroke(new java.awt.BasicStroke(3));
        g.drawRoundRect(margin, statsY, panelWidth, statsHeight, 15, 15);

        // 4.5. Desenho dos Stats (Texto)
        g.setFont(new Font("Arial", Font.BOLD, 18));
        g.setColor(COR_TEXTO_STATS); // Texto em Escuro Profundo para contraste no fundo bege

        int statsStartX = margin + 15;
        int statsGap = (statsHeight / 4);

        g.drawString("VIDA (LIFE): " + this.life, statsStartX, statsY + statsGap);
        g.drawString("DANO (DAMAGE): " + this.damage, statsStartX, statsY + (statsGap * 2));
        g.drawString("ESCUDO (SHIELD): " + this.shield, statsStartX, statsY + (statsGap * 3));

        g.dispose();
        this.cardImage = cardImage;
    }

    private BufferedImage resizeImage(BufferedImage originalImage, int targetWidth, int targetHeight) {
        Image resultingImage = originalImage.getScaledInstance(targetWidth, targetHeight, Image.SCALE_SMOOTH);
        BufferedImage outputImage = new BufferedImage(targetWidth, targetHeight, BufferedImage.TYPE_INT_ARGB);
        Graphics2D g2d = outputImage.createGraphics();
        g2d.drawImage(resultingImage, 0, 0, null);
        g2d.dispose();
        return outputImage;
    }

}
