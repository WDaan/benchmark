from flask import Flask, json, jsonify
from collections import Counter


class Occurrence:
    def __init__(self, num, count):
        self.num = num
        self.count = count

    def __eq__(self, other):
        return self.num == other.num

    def __lt__(self, other):
        return self.num < other.num

    def serialize(self):
        return {'num': self.num, 'count': self.count}


def get_occurrences():
    content = filter(None, open('./data.txt', 'r').read().split('\n'))
    occurrences = Counter(content)
    formatted = []

    for occ in occurrences.most_common():
        formatted.append(Occurrence(occ[0], occ[1]))

    return list(map(lambda x: x.serialize(), sorted(formatted)))

app = Flask(__name__)

@app.route('/', methods=['GET'])
def get():
    return json.dumps(get_occurrences())

if __name__ == '__main__':
    from waitress import serve
    serve(app, host="0.0.0.0", port=8000)