using System.Drawing;
using System.IO;

namespace AirBNB.Classes
{
    public static class resize
    {
        public static byte[] ResizeImage(byte[] imageBytes, int maxWidth, int maxHeight)
        {
            // Load the image from the byte array using a MemoryStream and the Image.FromStream method
            using var stream = new MemoryStream(imageBytes);
            using var image = Image.FromStream(stream);

            // Calculate the new size based on the maximum dimensions
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            // Resize the image using the Graphics.DrawImage method
            var resizedImage = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Save the resized image to a new MemoryStream using the Image.Save method
            using var resizedStream = new MemoryStream();
            resizedImage.Save(resizedStream, image.RawFormat);

            // Return the resized image as a byte array
            return resizedStream.ToArray();
        }
    }
}
