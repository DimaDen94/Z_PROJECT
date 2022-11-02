// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("jQLeknxLuaX01buxJ0utet2UALDX96P7tSrJoQOP0FKUMMXPJp6STVrDM2/5dlep01rtsZY+oQr1H7GeRKFY/6CHy01FENnhBa3EcPgbB2jVvRAnUabo4EyrKGno/clPpgBnKtWYzFnui72XaglUUUvlLDazok74WL/PCj+odj3N7tWwgm651sIXQNu+NHI19nNqDw3T4HDViO+zsA6U3+JT3JktVHpRegtILDn0N92SZktYf0Ojfk+P3+rI/Fot6Gfqa09xm78Qk52SohCTmJAQk5OSUMAOQWd5nqIQk7Cin5SbuBTaFGWfk5OTl5KRfPZ32q6zhd+29d8/yelT699HRL0Q/zr9WrL3JP6cNS7T3Zehnzwoirf2PPz7oo0du5CRk5KT");
        private static int[] order = new int[] { 12,8,2,10,6,5,11,13,9,13,13,12,13,13,14 };
        private static int key = 146;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
