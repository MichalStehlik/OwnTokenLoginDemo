import { useAuthContext } from "../../providers/AuthProvider";

export const Title = () => {
    const [{ profile, accessToken }] = useAuthContext();
    return (
        <>
            <p>Title</p>
            <pre>{accessToken}</pre>
            <pre>{JSON.stringify(profile," ",4)}</pre>
        </>
        
    );
}

export default Title;