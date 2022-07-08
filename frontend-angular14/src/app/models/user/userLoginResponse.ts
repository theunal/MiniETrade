

export interface UserLoginResponse {
    success: boolean
    message: string
    accessToken: {
        token: string
        expiration: string
    }
}