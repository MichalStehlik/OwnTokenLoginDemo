import { useNavigate } from 'react-router-dom'

export const Unauthorized = () => {
    const navigate = useNavigate();
    return (
        <>
            <h1>401</h1>
            <div><button onClick={e => {navigate(-1)}}>Back</button></div>
        </>
        
    );
}

export default Unauthorized;