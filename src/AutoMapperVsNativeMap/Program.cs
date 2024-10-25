using AutoMapperVsNativeMap;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<AutomapperVsNativeMap>();