import {useRequireAuth} from "../../hooks/useRequireAuth"

export const Create = () => {
    useRequireAuth();
    return (
        <p>Create</p>
    );
}

export default Create;