const kinveyUsername = 'guest';
const kinveyPassword = 'guest';
const appKey = 'kid_By7ypv4fr';
const appSecret = '0f9515cee128457aa4a46d833a9bc9d0';
const baseUrl = 'https://baas.kinvey.com/appdata/kid_By7ypv4fr/Books';

const elements = {
    btnSubmit: document.querySelector("body > form > button"),
    btnLoadBooks: document.querySelector("#loadBooks"),
    btnCancelEdit: document.querySelector("#cancelBtn"),
    btnDoneEdit: document.querySelector("#editBtn"),
    inputTitle: document.querySelector("#title"),
    inputAuthor: document.querySelector("#author"),
    inputIsbn: document.querySelector("#isbn"),
    tBodyBooks: document.querySelector("body > table > tbody"),
    h3Form: document.querySelector("body > form > h3")
};

elements.btnSubmit.addEventListener('click', addBook);
elements.btnLoadBooks.addEventListener('click', loadBooks);
elements.btnDoneEdit.addEventListener('click', editBook);
elements.btnCancelEdit.addEventListener('click', cancelEdit);

function addBook(ev) {
    ev.preventDefault(); // ne prezarejda stranicata

    let title = elements.inputTitle.value;
    let author = elements.inputAuthor.value;
    let isbn = elements.inputIsbn.value;

    if (title && author && isbn) {
        const dataObject = {
            title,
            author,
            isbn
        };


        const headers = {
            method: 'POST',
            body: JSON.stringify(dataObject),
            credentials: 'include',
            Authorization: 'Basic ' + btoa(`${kinveyUsername}:${kinveyPassword}`),
            headers: {
                'Content-Type': 'application/json'
            }
        };

        fetch(baseUrl, headers)
            .then(handler)
            .then(loadBooks)
            .catch(err => console.log(err));

        elements.inputTitle.value = '';
        elements.inputAuthor.value = '';
        elements.inputIsbn.value = '';
    }
}

function loadBooks() {
    const headers = {
        credentials: 'include',
        Authorization: 'Kinvey ' + localStorage.getItem('authToken'),
    }

    fetch(baseUrl, headers)
        .then(handler)
        .then((data) => {
            elements.tBodyBooks.innerHTML = '';

            data.forEach(book => {
                let trNextBook = document.createElement('tr');
                trNextBook.setAttribute('id', book._id);

                trNextBook.innerHTML = `<td> ${book.title}</td>
                <td> ${book.author}</td>
                <td> ${book.isbn}</td>
                <td>
                    <button class="btnEdit" value=${book._id}>Edit</button>
                    <button class="btnDelete" value=${book._id}>Delete</button>
                </td>`

                trNextBook.querySelector('button.btnEdit')
                    .addEventListener('click', () => loadEditForm(book._id));

                trNextBook.querySelector('button.btnDelete')
                    .addEventListener('click', () => deleteBook(book._id));

                elements.tBodyBooks.appendChild(trNextBook);
            })
        })

        .catch(err => console.error(err));
}

function loadEditForm(bookId) {
    let dataToEdit = document.getElementById(bookId)
        .querySelectorAll('td');

    elements.inputTitle.value = dataToEdit[0].textContent;
    elements.inputAuthor.value = dataToEdit[1].textContent;
    elements.inputIsbn.value = dataToEdit[2].textContent;

    elements.h3Form.textContent = 'EDIT BOOK';

    elements.btnSubmit.style.display = 'none';
    elements.btnDoneEdit.style.display = 'block';
    elements.btnCancelEdit.style.display = 'block';

    elements.btnDoneEdit.value = bookId;
}

function editBook(ev) {
    ev.preventDefault();

    let bookId = ev.target.value;
    ev.target.value = '';

    const bookData = {
        "title": elements.inputTitle.value,
        "author": elements.inputAuthor.value,
        "isbn": elements.inputIsbn.value
    };

    let editUrl = `${baseUrl}/${bookId}`;

    let headers = {
        method: 'PUT',
        body: JSON.stringify(bookData),
        credentials: 'include',
        Authorization: 'Kinvey' + localStorage.getItem('authToken'),
        headers: {
            "Content-Type": "application/json"
        }
    };

    fetch(editUrl, headers)
        .then(handler)
        .then(loadBooks)
        .catch(err => console.error(err));

    fromEditToSubmitForm();
}

function cancelEdit(ev) {
    ev.preventDefault();
    fromEditToSubmitForm();
}

function fromEditToSubmitForm() {
    elements.inputTitle.value = '';
    elements.inputAuthor.value = '';
    elements.inputIsbn.value = '';

    elements.h3Form.textContent = 'FORM';

    elements.btnSubmit.style.display = 'block';
    elements.btnDoneEdit.style.display = 'none';
    elements.btnCancelEdit.style.display = 'none';
}

function deleteBook(bookId) {
    let deleteUrl = `${baseUrl}/${bookId}`;

    const headers = {
        method: 'DELETE',
        credentials: 'include',
        Authorization: 'Kinvey' + localStorage.getItem('authToken'),
        headers: {
            "Content-Type": "application/json"
        }
    };

    fetch(deleteUrl, headers)
        .then(handler)
        .then(loadBooks)
        .catch(err => console.error(err));
}

function handler(response) {
    if (response.status >= 400) {
        throw new Error(response.status);
    }

    return response.json();
}