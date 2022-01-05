using BenchmarkDotNet.Attributes;

namespace KanaConvertStudy;

[Config(typeof(BenchmarkConfig))]
public class HiraganaJudgeBenchmark
{
    string Hiragana1 = string.Empty;
    string Hiragana2 = string.Empty;
    string Hiragana3 = string.Empty;

    [GlobalSetup]
    public void Setup()
    {
        Hiragana1 = "ひらがなひらがな";
        Hiragana2 = "カタカナカタカナ";
        Hiragana3 = "これはテストです";
    }

    [Benchmark]
    public bool CharRegex()
    {
        var isHiragana1 = KanaDetector.IsAllHiragana_Regex(Hiragana1);
        var isHiragana2 = KanaDetector.IsAllHiragana_Regex(Hiragana2);
        var isHiragana3 = KanaDetector.IsAllHiragana_Regex(Hiragana3);
        return isHiragana1 && isHiragana2 && isHiragana3;
    }

    [Benchmark]
    public bool CharForEach()
    {
        var isHiragana1 = KanaDetector.IsAllHiragana_CharForeach(Hiragana1);
        var isHiragana2 = KanaDetector.IsAllHiragana_CharForeach(Hiragana2);
        var isHiragana3 = KanaDetector.IsAllHiragana_CharForeach(Hiragana3);
        return isHiragana1;
    }

    [Benchmark]
    public bool CharFor()
    {
        var isHiragana1 = KanaDetector.IsAllHiragana_CharFor(Hiragana1);
        var isHiragana2 = KanaDetector.IsAllHiragana_CharFor(Hiragana2);
        var isHiragana3 = KanaDetector.IsAllHiragana_CharFor(Hiragana3);
        return isHiragana1;
    }

    [Benchmark]
    public bool CharForUnsafe()
    {
        var isHiragana1 = KanaDetector.IsAllHiragana_CharForUnsafe(Hiragana1);
        var isHiragana2 = KanaDetector.IsAllHiragana_CharForUnsafe(Hiragana2);
        var isHiragana3 = KanaDetector.IsAllHiragana_CharForUnsafe(Hiragana3);
        return isHiragana1;
    }

    [Benchmark]
    public bool CharLinq()
    {
        var isHiragana1 = KanaDetector.IsAllHiragana_CharLinq(Hiragana1);
        var isHiragana2 = KanaDetector.IsAllHiragana_CharLinq(Hiragana2);
        var isHiragana3 = KanaDetector.IsAllHiragana_CharLinq(Hiragana3);
        return isHiragana1;
    }
}

[Config(typeof(BenchmarkConfig))]
public class HiraganaToKatakanaBenchmark
{
    string Hiragana1 = string.Empty;
    string Hiragana2 = string.Empty;
    string Hiragana3 = string.Empty;

    [GlobalSetup]
    public void Setup()
    {
        //VB.NETを使うためのおまじない（Shift_JISがらみ）
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        Hiragana1 = "ひらがなひらがな";
        Hiragana2 = "カタカナカタカナ";
        Hiragana3 = "This is Test";
    }

    [Benchmark]
    public string VbStrConv()
    {
        string katakana = KanaConverter.ToKatakanaVB(Hiragana1);
        KanaConverter.ToKatakanaVB(Hiragana2);
        KanaConverter.ToKatakanaVB(Hiragana3);
        return katakana;
    }

    [Benchmark]
    public string CharLinq()
    {
        string katakana = KanaConverter.ToKatakanaCharLinq(Hiragana1);
        KanaConverter.ToKatakanaCharLinq(Hiragana2);
        KanaConverter.ToKatakanaCharLinq(Hiragana3);
        return katakana;
    }

    [Benchmark]
    public string CharFor()
    {
        string katakana = KanaConverter.ToKatakanaCharFor(Hiragana1);
        KanaConverter.ToKatakanaCharFor(Hiragana2);
        KanaConverter.ToKatakanaCharFor(Hiragana3);
        return katakana;
    }

    [Benchmark]
    public string CharForUnsafe()
    {
        string katakana = KanaConverter.ToKatakanaCharForUnsafe(Hiragana1);
        KanaConverter.ToKatakanaCharForUnsafe(Hiragana2);
        KanaConverter.ToKatakanaCharForUnsafe(Hiragana3);
        return katakana;
    }
}