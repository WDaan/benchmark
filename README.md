
# Benchmark

tests how fast webserver can read file (10k number), count & respond json

  

## command for testing

./bombardier -c 10 -d 20s http://localhost:3000 => 10 connections for 20s

./bombardier -c 30 -d 20s http://localhost:3000 => 30 connections for 20s



# C#

- package management: 0
- ease of programming: 2

![c# benchmark image](/results/csharp.png?raw=true "C# benchmark")

# Nodejs

- package management: 2
- ease of programming: 3

![Node benchmark image](/results/node.png?raw=true "Nodejs benchmark")

# Rust

- package management: 3
- ease of programming: 1

![rust benchmark image](/results/rust.png?raw=true "Rust benchmark")

# Php

![phpbenchmark image](/results/php.png?raw=true "php benchmark")

# Go

![Gobenchmark image](/results/Go.png?raw=true "Go benchmark")

# Python

![Gobenchmark image](/results/Go.png?raw=true "Go benchmark")