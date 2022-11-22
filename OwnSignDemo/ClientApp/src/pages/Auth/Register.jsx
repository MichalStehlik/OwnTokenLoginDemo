import { useForm } from "react-hook-form"
import axios from "axios"
import { useNavigate } from "react-router-dom"

export const Register = () => {
    const { register, handleSubmit, watch, formState: { errors } } = useForm();
    const onSubmit = data => {
        axios.post("/api/Authentication/register",
        {
            username: data.username,
            password: data.password
        }
        )
        .then(response => {
            console.log(response.data);
            navigate("/account/login");
        })
        .catch(error => {
            console.error(error);
        })
    };
    const navigate = useNavigate();
    return (
        <>
        <h1>Register</h1>
        <form onSubmit={handleSubmit(onSubmit)}>
            <div>
                <label>Username</label>
                <input defaultValue="user" {...register("username")} />
            </div>
            <div>
                <label>Password</label>
                <input type="password" {...register("password")} />
            </div>
            <div>
                <label>Password again</label>
                <input type="password" {...register("passwordCopy")} />
            </div>
            <div>
                <button type="submit">Register</button>
            </div>
        </form>
        </>
    );
}

export default Register;