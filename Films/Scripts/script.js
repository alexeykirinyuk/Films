var host = "http://" + window.location.hostname;

function href(path)
{
    document.location.href = host + path;
}

function films()
{
    href("Films/Index");
}
function actors()
{
    href("Actors/Index");
}