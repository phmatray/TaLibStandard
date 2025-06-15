using System.Text;

namespace Demo.Extensions;

internal static class IntegersExtensions
{
    public static string ToReadableString(this int[] integers)
    {
        StringBuilder sb = new();
        sb.Append('[');
        
        for (int i = 0; i < integers.Length; i++)
        {
            sb.Append(integers[i]);
            if (i < integers.Length - 1)
            {
                sb.Append(", ");
            }
        }
        
        sb.Append(']');
        return sb.ToString();
    }
}