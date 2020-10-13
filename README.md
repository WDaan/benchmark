
# Benchmark

Tastk:
- Read a file with 10k numbers
- split into array of strings
- count number of occurences
- host webserver & respond as json [{ num: x, count: y}, ...]

an easy yet difficult enough way to get a grasp of a language & it's features


## command for testing

./bombardier -c 10 -d 20s http://localhost:3000 => 10 connections for 20s

./bombardier -c 30 -d 20s http://localhost:3000 => 30 connections for 20s



# C#

- package management: 0
- ease of programming: **
- speed: **

![c# benchmark image](/results/csharp.png?raw=true "C# benchmark")

# Nodejs

- package management: **
- ease of programming: ***
- speed: *

![Node benchmark image](/results/node.png?raw=true "Nodejs benchmark")

# Rust

- package management: ***
- ease of programming: *
- speed: *****

![rust benchmark image](/results/rust.png?raw=true "Rust benchmark")

# Php

- package management: **
- ease of programming: ***
- speed: *

![phpbenchmark image](/results/php.png?raw=true "php benchmark")

# Go

![Gobenchmark image](/results/Go.png?raw=true "Go benchmark")

# Python

![Gobenchmark image](/results/Go.png?raw=true "Go benchmark")