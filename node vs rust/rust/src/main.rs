use actix_web::{get, App, HttpResponse, HttpServer, Responder};
use std::collections::HashMap;
use std::fs;
use std::path::Path;

mod occurrence;

use occurrence::Occurrence;

fn get_occurrences() -> HashMap<i32, i32> {
    let path = Path::new("data.txt");

    let contents = fs::read_to_string(path).expect("Something went wrong reading the file");

    let v: Vec<i32> = contents
        .split("\n")
        .filter(|s| !s.is_empty())
        .map(|x| x.trim().parse().unwrap())
        .collect();

    let mut occurrences: HashMap<i32, i32> = HashMap::new();

    for num in v.into_iter() {
        // word is a &str
        *occurrences.entry(num).or_insert(0) += 1;
    }

    return occurrences;
}

fn format(occs: &HashMap<i32, i32>) -> Vec<Occurrence> {
    let mut result: Vec<Occurrence> = Vec::new();
    for (num, count) in occs.iter() {
        result.push(Occurrence {
            count: *count,
            num: *num,
        });
    }
    return result.sort();
}

#[get("/")]
async fn hello() -> impl Responder {
    let occ = get_occurrences();
    let res = format(&occ);
    HttpResponse::Ok().json(res)
}

#[actix_web::main]
async fn main() -> std::io::Result<()> {
    HttpServer::new(|| App::new().service(hello))
        .bind("127.0.0.1:8000")?
        .run()
        .await
}
