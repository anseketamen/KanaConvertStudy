using System.Text.RegularExpressions;

namespace KanaConvertStudy;

public class KanaDetector
{
    private static readonly char HiraganaCharStart = 'ぁ'; // 0x3041
    private static readonly char HiraganaCharEnd = 'ゔ'; // 0x3094
    private static readonly char HiraganaKatakanaLongBar = 'ー'; // 0x30FC

    private static readonly Regex HiraganaRegex = new("^([ぁ-ゔ]|ー)*$");

    private static bool IsHiragana(char letter) => (letter >= HiraganaCharStart && letter <= HiraganaCharEnd) || letter == HiraganaKatakanaLongBar;

    /// <summary>
    /// 正規表現を使うバージョン
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsAllHiragana_Regex(string text)
    {
        if (text.Length == 0)
        {
            return false;
        }
        return HiraganaRegex.IsMatch(text);
    }

    /// <summary>
    /// stringをchar arrayにしてforで回すバージョン
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsAllHiragana_CharFor(string text)
    {
        if (text.Length == 0)
        {
            return false;
        }
for (var i = 0; i < text.Length; i++)
{
    if (!IsHiragana(text[i]))
    {
        return false;
    }
}

return true;
    }

    /// <summary>
    /// stringをchar arrayにしてforeachで回すバージョン
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsAllHiragana_CharForeach(string text)
    {
        if (text.Length == 0)
        {
            return false;
        }
        foreach (var t in text)
        {
            if (!IsHiragana(t))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// stringをUnsafeでごにょごにょするバージョン
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public unsafe static bool IsAllHiragana_CharForUnsafe(string text)
    {
        if (text.Length == 0)
        {
            return false;
        }
fixed (char* p = text)
{
    for (var i = 0; i < text.Length; i++)
    {
        if (!IsHiragana(p[i]))
        {
            return false;
        }
    }
}

        return true;
    }

    /// <summary>
    /// LINQを使うバージョン
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsAllHiragana_CharLinq(string text) => text.All(x => IsHiragana(x));
}
