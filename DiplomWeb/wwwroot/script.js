async function GetBook() {
    const response = await fetch("/api/books", {
        method: "GET", headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const books = await response.json();
        let rows = document.querySelector("tbody");
        books.forEach(book => {
            rows.append(row(book));
        });
    }
}

async function GetBookById(id) {
    const response = await fetch("/api/books/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        const book = await response.json();
        const form = document.forms["booksForm"]
        form.elements["id"].value = book.id;
        form.elements["title"].value = book.title;
        form.elements["author"].value = book.author;
        form.elements["genre"].value = book.genre;
        form.elements["releaseYear"].value = book.releaseYear;
        form.elements["adaptation"].value = book.adaptation;
    }
}

async function CreateBook(bookTitle, bookAuthor, bookGenre, bookReleaseYear, bookAdaptation) {
    const response = await fetch("api/books", {
        method: "POST",
        headers: {
            "Accept": "application/json", "Content-Type":
                "application/json"
        },
        body: JSON.stringify({
            title: bookTitle,
            author: bookAuthor,
            genre: bookGenre,
            releaseYear: bookReleaseYear,
            adaptation: bookAdaptation
        })
    });
    if (response.ok === true) {
        const book = await response.json();
        reset();
        document.querySelector("tbody").append(row(book));
    }
}

async function EditBook(bookId, bookTitle, bookAuthor, bookGenre, bookReleaseYear, bookAdaptation) {
    const response = await fetch("/api/books/" + bookId, {
        method: "PUT",
        headers: {
            "Accept": "application/json", "Content-Type":
                "application/json"
        },
        body: JSON.stringify({
            id: parseInt(bookId, 10),
            title: bookTitle,
            author: bookAuthor,
            genre: bookGenre,
            releaseYear: bookReleaseYear,
            adaptation: bookAdaptation
        })
    });
    if (response.ok === true) {
        const book = await response.json();
        reset();
        document.querySelector("tr[data-rowid='" + book.id + "']".replaceWith(row(book)));
    }
}

async function DeleteBook(idBook) {
    const response = await fetch("/api/books/" + idBook, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const book = await response.json();
        document.querySelector("tr[data-rowid='" + book.id + "']").remove();
    }
}

function reset() {
    const form = document.forms["booksForm"];
    form.reset();
    form.elements["id"].value = 0;
}

function row(book) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", book.id);
    const idTd = document.createElement("td")
    idTd.append(book.id);
    tr.append(idTd);
    const nameTd = document.createElement("td");
    nameTd.append(book.title);
    tr.append(nameTd);
    const authorTd = document.createElement("td");
    authorTd.append(book.author);
    tr.append(authorTd);
    const genreTd = document.createElement("td");
    genreTd.append(book.genre);
    tr.append(genreTd);
    const releaseYearTd = document.createElement("td");
    releaseYearTd.append(book.releaseYear);
    tr.append(releaseYearTd);
    const adaptationTd = document.createElement("td");
    adaptationTd.append(book.adaptationText);
    tr.append(adaptationTd);

    const linksTd = document.createElement("td");
    const editLink = document.createElement("a");
    editLink.setAttribute("data-id", book.id);
    editLink.setAttribute("style", "cursor:pointer;padding:15px;");
    editLink.append("Изменить");
    editLink.addEventListener("click", e => {
        e.preventDefault();
        GetBookById(book.id);
    });
    linksTd.append(editLink);

    const removeLink = document.createElement("a");
    removeLink.setAttribute("data-id", book.id);
    removeLink.setAttribute("style", "cursor:pointer;padding:15px;");
    removeLink.append("Удалить");
    removeLink.addEventListener("click", e => {
        e.preventDefault();
        DeleteBook(book.id);
    });
    linksTd.append(removeLink);
    tr.appendChild(linksTd);
    return tr;
}

function InitialFunction() {
    document.getElementById("reset").addEventListener("click", e => {
        e.preventDefault();
        reset();
    });
    document.forms["booksForm"].addEventListener("submit", e => {
        e.preventDefault();
        const form = document.forms["booksForm"];
        const id = form.elements["id"].value;
        const title = form.elements["title"].value;
        const author = form.elements["author"].value;
        const genre = form.elements["genre"].value;
        const releaseYear = form.elements["releaseYear"].value;
        const adaptation = form.elements["adaptation"].value;
        boolAdaptation = false;
        if (adaptation === "true") boolAdaptation = true;
        else boolAdaptation = false;
        if (id == 0)
            CreateBook(title, author, genre, releaseYear, boolAdaptation);
        else
            EditBook(id, title, author, genre, releaseYear, boolAdaptation);
    });
    GetBook();
}

