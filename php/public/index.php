<?php

use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Slim\Factory\AppFactory;

require __DIR__ . '/../vendor/autoload.php';

$app = AppFactory::create();

function getOccurrence()
{
    $numbers = file('../../data.txt', FILE_IGNORE_NEW_LINES | FILE_SKIP_EMPTY_LINES);

    $results = [];

    foreach ($numbers as $num) {
        if (!isset($results[$num])) $results[$num] = ["count" => 0, "num" => $num];
        $results[$num]['count'] += 1;
    }

    $formatted = array_values($results);

    usort($formatted, fn ($a, $b) => strcmp($a['num'], $b['num']));

    return json_encode($formatted);
}

$app->get('/', function (Request $request, Response $response, $args) {
    $response->getBody()->write(getOccurrence());
    return $response
        ->withHeader('Content-Type', 'application/json');
});

$app->run();
