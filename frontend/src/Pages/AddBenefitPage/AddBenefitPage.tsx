// import s from './AddBenefit.module.css';
// import { useState } from 'react';
// import axios, { AxiosResponse } from 'axios';
// import { useField, Form, Formik } from 'formik';

// Страница добавления льготы пока не работает, прошу игнорировать ошибки на этой странице
// Я решил полностью переписать этот компонент с использованием библиотеки Formik, но пока не успел.

// const MyTextInput = ({ label, ...props }: Props) => {
//     const [field, meta] = useField(props);
//     return (
//         <div className={`flex ${s.input_wrap}`}>
//             <label className={s.label} htmlFor={props.id || props.name}>
//                 {label}
//             </label>
//             <input className={s.input} {...field} {...props} />
//             {meta.touched && meta.error ? <p className={s.error}>{meta.error}</p> : null}
//         </div>
//     );
// };

// const AddBenefitPage = () => {
//     const defaultValues = {
//         name: '',
//         category: '',
//         description: '',
//         validityPeriodDays: 0,
//         realPrice: 0,
//         experienceYearsRequired: 0,
//         ucoinPrice: 0,
//         additionalInfo: '',
//         formUrl: '',
//         onboardingRequired: false,
//     };

//     const addBenefit = () => {
//         const token = localStorage.getItem('authToken');
//         console.log(token);
//         axios
//             .post(
//                 'benefits',
//                 {
//                 },
//                 {
//                     headers: {
//                         Authorization: `Bearer ${token}`,
//                     },
//                 }
//             )
//             .then((response: AxiosResponse) => {
//                 console.log(response);
//             })
//             .catch(error => {
//                 console.log(error);
//             });
//     };

//     return (
//         <Formik
//             validateOnChange={false}
//             validateOnBlur={false}
//             initialValues={{
//             }}
//             validate={(values) => {
//                 const errors = {};
//                 return errors;
//             }}
//             onSubmit={(values, { setSubmitting }) => {
//             }}>
//             {({ isSubmitting }) => (
//                 <Form className={`flex ${s.register_form}`}>
//                         <MyTextInput
//                             label='Фамилия'
//                             name='lastName'
//                             id='lastName'
//                             type='text'
//                             placeholder='Иванов'
//                         />
//                     <button className={s.button} type='submit' disabled={isSubmitting}>
//                         Создать льготу
//                     </button>
//                 </Form>
//             )}
//         </Formik>
//     );
// };

// export default AddBenefitPage;
