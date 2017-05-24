var url = window.location.href;
var arr = url.split("/");
var host = arr[0] + "//" + arr[2] + "/";

function href(path)
{
    document.location.href = host + path;
}

function hrefAction(controller, action, id)
{
    var uri = controller + "/" + action;

    if (null != id)
    {
        uri += "?id=" + id
    }

    href(uri);
}
function hrefStart()
{
    hrefAction("Start", "Index");
}
function hrefFilm(action, id)
{
    hrefAction("Films", action, id);
}
function hrefActor(action, id)
{
    hrefAction("Actors", action, id);
}
