```

BenchmarkDotNet v0.14.0, Ubuntu 24.04.1 LTS (Noble Numbat) WSL
11th Gen Intel Core i5-11300H 3.10GHz, 1 CPU, 6 logical and 3 physical cores
.NET SDK 8.0.112
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                | Mean     | Error    | StdDev    | Median   | Rank | Gen0       | Gen1       | Gen2      | Allocated |
|---------------------- |---------:|---------:|----------:|---------:|-----:|-----------:|-----------:|----------:|----------:|
| ListAndPredicate      |       NA |       NA |        NA |       NA |    ? |         NA |         NA |        NA |        NA |
| DictionaryAndContains |  5.246 s | 0.0536 s |  0.0501 s |  5.248 s |    1 | 93000.0000 | 32000.0000 | 2000.0000 | 677.87 MB |
| HashSetAndContains    | 11.621 s | 0.8149 s |  2.4026 s | 11.872 s |    2 | 91000.0000 | 30000.0000 |         - | 655.97 MB |
| ListAndLINQ           | 74.942 s | 8.5506 s | 25.2117 s | 52.558 s |    3 | 66000.0000 |          - |         - |  326.5 MB |

Benchmarks with issues:
  Benchmarker_1000_Element.ListAndPredicate: DefaultJob
