```

BenchmarkDotNet v0.14.0, Ubuntu 24.04.1 LTS (Noble Numbat) WSL
11th Gen Intel Core i5-11300H 3.10GHz, 1 CPU, 6 logical and 3 physical cores
.NET SDK 8.0.112
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                | Mean     | Error    | StdDev   | Median   | Rank | Gen0       | Gen1       | Allocated |
|---------------------- |---------:|---------:|---------:|---------:|-----:|-----------:|-----------:|----------:|
| ListAndPredicate      |  2.671 s | 0.0526 s | 0.0585 s |  2.642 s |    1 |          - |          - |   1.79 MB |
| DictionaryAndContains |  6.423 s | 0.1260 s | 0.1999 s |  6.380 s |    2 | 91000.0000 | 30000.0000 | 676.69 MB |
| HashSetAndContains    |  6.809 s | 0.2199 s | 0.6309 s |  6.512 s |    2 | 91000.0000 | 30000.0000 | 656.25 MB |
| ListAndLINQ           | 11.591 s | 0.2226 s | 0.2382 s | 11.596 s |    3 | 66000.0000 |          - | 326.01 MB |
