function validate(obj) {
    const uriRegex = /(^[\w.]+$)/;
    const messageRegex = /([<>\\&'"])/;

    const methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    if (!obj.method || !methods.includes(obj.method)) {
        throw new Error("Invalid request header: Invalid Method");
    }

    if (!obj.uri || obj.uri == '' || !uriRegex.test(obj.uri)) {
        throw new Error("Invalid request header: Invalid URI");
    }

    if (!obj.version || !versions.includes(obj.version)) {
        throw new Error("Invalid request header: Invalid Version");
    }

    if (obj.message == undefined || messageRegex.test(obj.message)) {
        throw new Error("Invalid request header: Invalid Message");
    }

    return obj;
}