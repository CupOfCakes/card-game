package main.java.server.util;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;

public class ImageUtils {

    private static int verificator (byte[] imgBytes){
        if(imgBytes == null || imgBytes.length == 0){
            return 0;
        }

        return 1;
    }


    public static BufferedImage readBImageFromBytes(byte[] imgBytes){
        if(verificator(imgBytes) == 0){
            return null;
        }

        try(ByteArrayInputStream bais = new ByteArrayInputStream(imgBytes)){
            return ImageIO.read(bais);
        } catch (IOException e){
            e.printStackTrace();
            return null;
        }

    }

    public static Image readImageFromBytes(byte[] imgBytes){
        if(verificator(imgBytes) == 0){
            return null;
        }

        try(ByteArrayInputStream bais = new ByteArrayInputStream(imgBytes)){
            return ImageIO.read(bais);
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }

    }

    public static byte[] imageToBytes(BufferedImage image){
        if(image == null) return null;

        try(ByteArrayOutputStream baos = new ByteArrayOutputStream()){
            ImageIO.write(image, "png", baos);
            return baos.toByteArray();
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
    }

    public static BufferedImage imageToBufferedImage(Image img){
        if(img instanceof BufferedImage) return (BufferedImage)img;

        BufferedImage bimage = new BufferedImage(
                img.getWidth(null),
                img.getHeight(null),
                BufferedImage.TYPE_INT_ARGB
        );

        Graphics2D g2d = bimage.createGraphics();
        g2d.drawImage(img, 0, 0, null);
        g2d.dispose();
        return bimage;
    }

}
