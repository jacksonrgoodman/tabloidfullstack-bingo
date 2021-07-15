import { getToken } from './authManager'

const baseUrl = '/api/Comment';

export const getCommentsByPostId = (id) => {
    return getToken().then((token) => {
        return fetch(`${baseUrl}/${id}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(res => {
            if (res.ok) {
                return res.json();
            }
            else {
                throw new Error("An unknown error occurred while trying to fetch comments");
            }
        });
    });
};