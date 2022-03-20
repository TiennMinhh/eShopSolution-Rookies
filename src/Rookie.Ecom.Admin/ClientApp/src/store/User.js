const requestUserType = 'REQUEST_USERS';
const receiveUserType = 'RECEIVE_USERS';
const initialState = { users: [], isLoading: false };

export const actionCreators = {
    requestUsers: page => async (dispatch, getState) => {
        if (page === getState().users.page) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }

        dispatch({ type: requestUserType, page });

        const url = `api/User/find?page=${page}`;
        const response = await fetch(url);
        const data = await response.json();
        const users = data.items;
        dispatch({ type: receiveUserType, page, users });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestUserType) {
        return {
            ...state,
            page: action.page,
            isLoading: true
        };
    }

    if (action.type === receiveUserType) {
        return {
            ...state,
            page: action.page,
            users: action.users,
            isLoading: false
        };
    }

    return state;
};
