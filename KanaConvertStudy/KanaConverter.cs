using Microsoft.VisualBasic;

namespace KanaConvertStudy;

public class KanaConverter
{
    private static readonly char HiraganaCharStart = 'ぁ'; // 0x3041
    private static readonly char HiraganaCharEnd = 'ゔ'; // 0x3094
    private static readonly char HiraganaToKatakanaOffset = (char)0x60;
    private static readonly char HiraganaKatakanaLongBar = 'ー'; // 0x30FC

    private static bool IsHiragana(char letter) => HiraganaCharStart <= letter && letter <= HiraganaCharEnd;

    /// <summary>
    /// VB.NETのStrConvを使うバージョン
    /// </summary>
    /// <param name="hiragana"></param>
    /// <returns></returns>
    public static string ToKatakanaVB(string hiragana)
    {
        //Windowsでしか動かないコード
#pragma warning disable CA1416 
        return Strings.StrConv(hiragana, VbStrConv.Katakana, 0x411) ?? throw new Exception();
#pragma warning restore CA1416
    }

    /// <summary>
    /// stringをchar arrayとしてforで回すバージョン
    /// </summary>
    /// <param name="hiragana"></param>
    /// <returns></returns>
    public static string ToKatakanaCharFor(string hiragana)
    {
        var text = hiragana.ToCharArray();
        for (var i = 0; i < hiragana.Length; i++)
        {
            if (IsHiragana(text[i]))
            {
                text[i] = (char)(text[i] + HiraganaToKatakanaOffset);
            }
        }
        return new string(text);
    }

    /// <summary>
    /// stringをchar arrayとしてLINQで回すバージョン
    /// </summary>
    /// <param name="hiragana"></param>
    /// <returns></returns>
    public static string ToKatakanaCharLinq(string hiragana) =>
        new string(hiragana.Select(x => IsHiragana(x) ? (char)(x + HiraganaToKatakanaOffset) : x).ToArray());

    /// <summary>
    /// stringをUnsafeでごにょごにょするバージョン
    /// </summary>
    /// <param name="hiragana"></param>
    /// <returns></returns>
    public unsafe static string ToKatakanaCharForUnsafe(string hiragana)
    {
        fixed (char* p = hiragana)
        {
            for (var i = 0; i < hiragana.Length; i++)
            {
                if (IsHiragana(p[i]))
                {
                    p[i] = (char)(p[i] + HiraganaToKatakanaOffset);
                }
            }
        }
        return hiragana;
    }
}
