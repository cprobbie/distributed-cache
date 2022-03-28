# distributed-cache
Playground for distributed caching using Redis.
Thanks to https://towardsdev.com/hands-on-distributed-cache-using-redis-minimal-api-with-net-core-6-c97309749db0
I copied the code from there and set it up to play around. It doesn't show how to set up Redis so I had to work it out myself.

## How to run

Pull official Redis image from Docker Hub and run it at port 6379
```
docker run --name some-redis -p 6379:6379 -d redis redis-server --save 60 1 --loglevel warning
```

Once redis container is ready, you can run the ASP.NET Core app and enjoy the distributed cache feature
## How to verify

```
docker exec -it some-redis bash
```
```
redis-cli
```
```
KEYS *
```

Your first request should add a key to the store which will expire (disappear) after 60 seconds.

