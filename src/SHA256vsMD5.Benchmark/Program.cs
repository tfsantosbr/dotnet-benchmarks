using BenchmarkDotNet.Running;
using SHA256vsMD5.Benchmark;

var summary = BenchmarkRunner.Run<Md5VsSha256>();
