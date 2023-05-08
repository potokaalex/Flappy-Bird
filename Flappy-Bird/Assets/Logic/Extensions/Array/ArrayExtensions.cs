namespace FlappyBird.Extensions
{
    public static class ArrayExtensions
    {
        public static bool Contains<T>(this T[] array, T item)
        {
            for (var i = 0; i < array.Length; i++)
                if (array[i].Equals(item))
                    return true;

            return false;
        }
    }
}
