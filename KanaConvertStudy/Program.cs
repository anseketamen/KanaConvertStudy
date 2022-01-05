using System.Diagnostics;
using BenchmarkDotNet;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Diagnosers;

namespace KanaConvertStudy;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<HiraganaJudgeBenchmark>();
        BenchmarkRunner.Run<HiraganaToKatakanaBenchmark>();
    }

}
public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        //はてなブログに貼り付ける用
        AddExporter(MarkdownExporter.Default);
        //メモリ使用量チェック
        AddDiagnoser(MemoryDiagnoser.Default);

        //長いと大変なのでショートラン
        AddJob(Job.ShortRun);
        //AddJob(Job.Default);
    }
}
