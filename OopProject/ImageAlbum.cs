using Microsoft.Xna.Framework.Graphics;

namespace OopProject
{
    public static class ImageAlbum
    {
        private static Texture2D warrior;
        private static string warriorPath = "";

        public static Texture2D GetWarriorTexture()
        {
            if (warrior != null)
            {
                return warrior;
            }
            else
            {
                //warrior = Loader.LoadImg(path);
            }
            return warrior;
        }
    }
}
