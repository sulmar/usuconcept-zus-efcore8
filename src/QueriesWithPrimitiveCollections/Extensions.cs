public static class Extensions
{
    public static void Dump<T>(this IEnumerable<T> elements)
    {
        foreach (var element in elements)
        {
            element.ToString();            
        }
    }
}
