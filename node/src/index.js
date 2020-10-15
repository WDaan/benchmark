const fs = require('fs')
const fastify = require('fastify')({
    logger: true
})

function countOccurence() {
    const rstream = fs.createReadStream('../data.txt')

    const results = []
    return new Promise((resolve, reject) => {
        rstream.on('data', chunk => {
            const res = chunk.toString()
            res.split('\n').forEach(num => {
                if (!results[num]) results[num] = { count: 0, num }
                results[num].count += 1
            })
        })

        rstream.on('close', () => {
            resolve(results)
        })

        rstream.on('error', e => reject(e))
    })
}

// Declare a route
fastify.get('/', async (req, res) => {
    const result = await countOccurence()
    res.send(result)
})

// Run the server!
fastify.listen(3000, '0.0.0.0', (err, address) => {
    if (err) {
        fastify.log.error(err)
        process.exit(1)
    }
    fastify.log.info(`server listening on ${address}`)
})
