package main.java.server.util;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
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

}
