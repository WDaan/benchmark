package main

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"log"
	"net/http"
	"strconv"
	"strings"
	"sort"

	"github.com/gorilla/mux"
)

type Occurrence struct {
	Num   int `json:"num"`
	Count int `json:"count"`
}

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func Filter(arr []string, cond func(string) bool) []string {
	result := []string{}
	for i := range arr {
		if cond(arr[i]) {
			result = append(result, arr[i])
		}
	}
	return result
}

func getOccurrences() []Occurrence {
	data, err := ioutil.ReadFile("data.txt")
	check(err)

	numbersAsStrings := Filter(strings.Split(string(data), "\n"), func(c string) bool { return len(c) != 0 })

	var numbers = []int{}

	//format to int
	for _, i := range numbersAsStrings {
		j, err := strconv.Atoi(i)
		if err != nil {
			panic(err)
		}

		numbers = append(numbers, j)
	}

	//count number of occs
	dict := make(map[int]int)
	for _, num := range numbers {
		dict[num] = dict[num] + 1
	}

	//map to Occurences
	occurrences := []Occurrence{}

	for num, count := range dict {
		occurrences = append(occurrences, Occurrence{Num: num, Count: count})
	}

	//sort
	sort.Slice(occurrences, func(i, j int) bool {
		return occurrences[i].Num < occurrences[j].Num
	})

	return occurrences
}

func get(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusOK)
	occurrences := getOccurrences()
	data, _ := json.Marshal(occurrences)
	w.Write(data)
}

func main() {
	r := mux.NewRouter().StrictSlash(true)
	r.HandleFunc("/", get)
	fmt.Print("Server listening on port 8000...")
	http.Handle("/", r)

	srv := &http.Server{
		Handler: r,
		Addr:    "0.0.0.0:8000",
	}

	log.Fatal(srv.ListenAndServe())
}
