# Benchmark
tests how fast webserver can read file (10k number), count & respond json

command for testing

./bombardier -c 10 -d 20s http://localhost:3000
./bombardier -c 30 -d 20s http://localhost:3000