import { useForm } from "react-hook-form"

export const Register = () => {
    const { register, handleSubmit, watch, formState: { errors } } = useForm();
    const onSubmit = data => console.log(data);
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