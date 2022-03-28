# distributed-cache
Playground for distributed caching using Redis

## How to run

Pull official Redis image from Docker Hub and run it at port 6379
```
docker run --name some-redis -p 6379:6379 -d redis redis-server --save 60 1 --loglevel warning
```

Once redis container is ready, you can run the ASP.NET Core app and enjoy the distributed cache
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

Your first request should add a key to the store which will expire after 60 seconds.

