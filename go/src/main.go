package main

import (
	"fmt"
	"io/ioutil"
	"strings"
)

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func main() {
	dat, err := ioutil.ReadFile("data.txt")
	check(err)

	numbers := strings.Split(string(dat), "\n")

	fmt.Print(numbers)
}
